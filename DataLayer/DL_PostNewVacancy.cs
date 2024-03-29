﻿using EmployeePortal.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeePortal.DataLayer
{
    public class DL_PostNewVacancy : DL_Base
    {
        public string FnAddNewJobVacancy(CT_PostNewJobs Obj_CT_PostJob)
        {
            string returntype = "";
            try
            {
                using (con)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_AddNewJobVacancy", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        
                        cmd.Parameters.AddWithValue("@PoJob_PKID", Obj_CT_PostJob.PoJob_PKID);
                        cmd.Parameters.AddWithValue("@DepartmenName", Obj_CT_PostJob.DepartmenName);
                        cmd.Parameters.AddWithValue("@Designation", Obj_CT_PostJob.Designation);
                        cmd.Parameters.AddWithValue("@Experience", Obj_CT_PostJob.Experience);
                        cmd.Parameters.AddWithValue("@Description", Obj_CT_PostJob.Description);
                        cmd.Parameters.AddWithValue("@Note", Obj_CT_PostJob.Note);
                        cmd.Parameters.AddWithValue("@CreatedBy", Obj_CT_PostJob.CreatedBy);


                        cmd.Parameters.Add("@msg", SqlDbType.VarChar, 40);
                        cmd.Parameters["@msg"].Direction = ParameterDirection.Output;

                        con.Open();
                        Convert.ToString(cmd.ExecuteNonQuery());
                        returntype = (string)cmd.Parameters["@msg"].Value;

                        con.Close();
                    }
                }
                return returntype;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public List<CT_PostNewJobs> FnGetAllJobVacancy()
        {
            List<CT_PostNewJobs> CT_PostNewJobs_list = new List<CT_PostNewJobs>();
            try
            {
                using (con)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_GetAllJobVacancy", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            CT_PostNewJobs obj = new CT_PostNewJobs();
                            obj.PoJob_PKID = Convert.ToInt32(reader["PoJob_PKID"].ToString());
                            obj.DepartmenName = reader["DepartmenName"].ToString();
                            obj.Designation = reader["Designation"].ToString();
                            obj.Experience = reader["Experience"].ToString();

                            obj.Description = reader["Description"].ToString();
                            obj.Note = reader["Note"].ToString();
                            obj.CreatedOn = Convert.ToDateTime(reader["CreatedOn"].ToString());
                            obj.CreatedOnFormat = Convert.ToString(obj.CreatedOn.Date.ToString("yyyy/MM/dd"));
                            obj.Status = reader["Status"].ToString();
                           

                            CT_PostNewJobs_list.Add(obj);
                        }

                        return CT_PostNewJobs_list;
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

   

        public string DeletePostedJobById(int PostedJob_PKID)
        {
            string returntype = "";
            CT_CreateEmployee obj = new CT_CreateEmployee();
            try
            {
                using (con)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("SpDeletePostedJobById", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PostedJob_PKID", PostedJob_PKID);
                        cmd.Parameters.Add("@msg", SqlDbType.VarChar, 40);
                        cmd.Parameters["@msg"].Direction = ParameterDirection.Output;
                        con.Open();
                        Convert.ToString(cmd.ExecuteNonQuery());
                        returntype = (string)cmd.Parameters["@msg"].Value;
                        con.Close();
                    }
                }
                return returntype;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public List<CT_ReferanceResume> FnViewEmployeeAppliedJob()
        {
            List<CT_ReferanceResume> CT_ReferanceResume_list = new List<CT_ReferanceResume>();
            try
            {
                using (con)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_ViewEmployeeAppliedJob", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;

                        con.Open();
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            CT_ReferanceResume obj = new CT_ReferanceResume();
                            obj.Refer_PKID = Convert.ToInt32(reader["Refer_PKID"].ToString());
                            obj.EmployeePKID = Convert.ToInt32(reader["EmployeePKID"].ToString());
                            obj.PostNewJobPKID = Convert.ToInt32(reader["PostNewJobPKID"].ToString());
                            obj.Resume = reader["Resume"].ToString();
                            obj.CreatedOn = Convert.ToDateTime(reader["CreatedOn"].ToString());
                            obj.CreatedOnFormat  = Convert.ToString(obj.CreatedOn.Date.ToString("yyyy/MM/dd"));
                            obj.Status = reader["Status"].ToString();
                            obj.HRComment = reader["HRComment"].ToString();
                            obj.EmployeeName = reader["EmployeeName"].ToString();
                            
                            CT_ReferanceResume_list.Add(obj);
                        }
                        return CT_ReferanceResume_list;
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public string FnAddApproveRejectCandidateResume(string status, string HRComment,int EmployeePKID, int Ref_PKID)
        {
            string returntype = "";
            try
            {
                using (con)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_AddApproveRejectCandidateResume", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@HRComment", HRComment);
                        cmd.Parameters.AddWithValue("@CreatedBy", EmployeePKID);
                        cmd.Parameters.AddWithValue("@Ref_PKID", Ref_PKID);
                        cmd.Parameters.Add("@msg", SqlDbType.VarChar, 40);
                        cmd.Parameters["@msg"].Direction = ParameterDirection.Output;
                        con.Open();
                        Convert.ToString(cmd.ExecuteNonQuery());
                        returntype = (string)cmd.Parameters["@msg"].Value;

                        con.Close();
                    }
                }
                return returntype;
            }
            catch (Exception ex)
            {

                throw;
            }

        }



        public List<CT_ReferanceResume> FnSearchStaus(string searchStatus)
        {
            List<CT_ReferanceResume> CT_ReferanceResume_list = new List<CT_ReferanceResume>();
            try
            {
                using (con)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_SearchStatus", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@searchStatus", searchStatus);
                        con.Open();
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            CT_ReferanceResume obj = new CT_ReferanceResume();
                            obj.Refer_PKID = Convert.ToInt32(reader["Refer_PKID"].ToString());
                            obj.EmployeePKID = Convert.ToInt32(reader["EmployeePKID"].ToString());
                            obj.PostNewJobPKID = Convert.ToInt32(reader["PostNewJobPKID"].ToString());
                            obj.Resume = reader["Resume"].ToString();
                            obj.Status = reader["Status"].ToString();
                            obj.CreatedOn = Convert.ToDateTime(reader["CreatedOn"].ToString());
                            obj.HRComment = reader["HRComment"].ToString();
                            obj.EmployeeName = reader["EmployeeName"].ToString();

                            CT_ReferanceResume_list.Add(obj);
                        }

                        return CT_ReferanceResume_list;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }



    }
}